    public class BarcodeScannedEventArgs : EventArgs {
    
        public BarcodeScannedEventArgs(string text) {
          mText = text;
        }
        public string ScannedText { get { return mText; } }
    
        private readonly string mText;
      }
    
      public class BarCodeListener : IDisposable {
        DateTime _lastKeystroke = new DateTime(0);
        string _barcode = string.Empty;
        Form _form;
        bool isKeyPreview;
    
        public bool ProcessCmdKey(ref Message msg, Keys keyData) {
          bool res = processKey(keyData);
          return keyData == Keys.Enter ? res : false;
        }
    
        protected bool processKey(Keys key) {
          // check timing (>7 keystrokes within 50 ms ending with "return" char)
          TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
          if (elapsed.TotalMilliseconds > 50) {
            _barcode = string.Empty;
          }
    
          // record keystroke & timestamp -- do NOT add return at the end of the barcode line
          if (key != Keys.Enter) {
            _barcode += (char)key;
          }
          _lastKeystroke = DateTime.Now;
    
          // process barcode only if the return char is entered and the entered barcode is at least 7 digits long.
          // This is a "magical" rule working well for EAN-13 and EAN-8, which both have at least 8 digits...
          if (key == Keys.Enter && _barcode.Length > 7) {
            if (BarCodeScanned != null) {
              BarCodeScanned(_form, new BarcodeScannedEventArgs(_barcode));
            }
            _barcode = string.Empty;
            return true;
          }
          return false;
        }
    
        public event EventHandler<BarcodeScannedEventArgs> BarCodeScanned;
    
        public BarCodeListener(Form f) {
          _form = f;
          isKeyPreview = f.KeyPreview;
          // --- set preview and register event...
          f.KeyPreview = true;
        }
    
        public void Dispose() {
          if (_form != null) {
            _form.KeyPreview = isKeyPreview;
            //_form.KeyPress -= KeyPress_scanner_preview;
          }
        }
      }
    }
