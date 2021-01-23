    public RelayCommand Remove
    {
        get
        {
            if (_Remove == null)
            {
                _Remove = new RelayCommand(
                    () => { Items.Remove(this.SelectedItem); _UOF.ProductHistoryRepository.Delete(this.SelectedItem); _UOF.Commit(); },
                    () => SelectedItem != null);
            }
            return _Remove;
        }
    }
