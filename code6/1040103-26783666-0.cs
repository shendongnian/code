    public enum NfcHelperState
    {
        Initializing,
        Ready,
        WaitingForWriting,
        FinishedWriting,
        ErrorWriting,
        NoDeviceFound
    }
    public class NfcHelper
    {
        private NfcHelperState _state = NfcHelperState.Initializing;
        public NfcHelperState State
        {
            get { return _state; }
        }
        
        private ProximityDevice _nfcDevice;
        private long? _writingMessageId;
        public NfcHelper()
        {
            Init();
        }
        public void Init()
        {
            UpdateState();
            _nfcDevice = ProximityDevice.GetDefault();
            if (_nfcDevice == null)
            {
                UpdateState(NfcHelperState.NoDeviceFound);
                return;
            }
            UpdateState(NfcHelperState.Ready);
        }
        private void UpdateState(NfcHelperState? state = null)
        {
            if (state.HasValue)
            {
                _state = state.Value;
            }
            if (OnStatusMessageChanged != null)
            {
                OnStatusMessageChanged(this, _state);
            }
        }
        public void WriteToTag()
        {
            StopWritingMessage();
            UpdateState(NfcHelperState.WaitingForWriting);
            try
            {
                var str = new StringBuilder();
                str.Append("action=my_custom_action");
                str.Append("\tWindowsPhone\t{");
                str.Append(CurrentApp.AppId);
                str.Append("}");
                _writingMessageId = _nfcDevice.PublishBinaryMessage("LaunchApp:WriteTag", GetBufferFromString(str.ToString()),
                    WriteToTagComplete);
            }
            catch
            {
                UpdateState(NfcHelperState.ErrorWriting);
                StopWritingMessage();
            }
        }
        private void WriteToTagComplete(ProximityDevice sender, long messageId)
        {
            UpdateState(NfcHelperState.FinishedWriting);
            StopWritingMessage();
        }
        private void StopWritingMessage()
        {
            if (_writingMessageId.HasValue)
            {
                _nfcDevice.StopPublishingMessage(_writingMessageId.Value);
                _writingMessageId = null;
            }
        }
        private static IBuffer GetBufferFromString(string str)
        {
            using (var dw = new DataWriter())
            {
                dw.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf16LE;
                dw.WriteString(str);
                return dw.DetachBuffer();
            }
        }
        public delegate void NfcStatusMessageChangedHandler(object myObject, NfcHelperState newState);
        public event NfcStatusMessageChangedHandler OnStatusMessageChanged;
    }
