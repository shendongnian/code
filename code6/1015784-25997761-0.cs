    public class MyFileWatcher {
       private TextBox _textBox;
       private ListBox _listBox;
       FileSystemWatcher _watcher;
       public MyFileWatcher(TextBox textBox, ListBox listBox, Object syncObj) {
           this._textBox = textBox;
           this._listBox = listBox;
           this._watcher = new FileSystemWatcher();
           this._watcher.SynchronizingObject = syncObj;
           this._watcher.Changed += new FileSystemEventHandler(convertXML);
           this._watcher.EnableRaisingEvents = true;
           this._watcher.IncludeSubdirectories = false;
           this._watcher.Path = textBox.Text;
           // add any other required initialization of the FileSystemWatcher here. 
       }
       protected virtual void convertXML(object source, FileSystemEventArgs f) {
           // interact with this._textBox and this._listBox here as required.
           // e.g.
           // this._textBox = f.FullPath;
       }
    }
