    public abstract class CloneAbleBase<T> : ObservableObjectEx, ICloneable, IEditableObject
        where T : DataBase<T>, new()
    {
        protected T CurrentData = new T();
        private T _backupData;
        private bool _isInEditMode;
        public object Clone()
        {
            var dataObject = (CloneAbleBase<T>) MemberwiseClone();
            dataObject.CurrentData = CurrentData.Copy();
            return dataObject;
        }
        public void BeginEdit()
        {
            if (_isInEditMode) return;
            _backupData = CurrentData.Copy();
            _isInEditMode = true;
        }
        public void EndEdit()
        {
            if (!_isInEditMode) return;
            _backupData = default(T);
            _isInEditMode = false;
            RaisePropertyChanged(string.Empty);
        }
        public void CancelEdit()
        {
            if (!_isInEditMode) return;
            CurrentData = _backupData;
            RaisePropertyChanged(string.Empty);
        }
    }
