            public void MoveFirst() {
                this.GetDefaultView().MoveCurrentToFirst();
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPosition"));
            }
            public void MovePrevious() {
                this.GetDefaultView().MoveCurrentToPrevious();
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPosition"));
            }
            public void MoveNext() {
                this.GetDefaultView().MoveCurrentToNext();
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPosition"));
            }
            public void MoveLast() {
                this.GetDefaultView().MoveCurrentToLast();
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPosition"));
            }
