            public void MoveFirst() {
                this.GetDefaultView().MoveCurrentToFirst();
                RaisePropertyChanged("CurrentPosition");
            }
            public void MovePrevious() {
                this.GetDefaultView().MoveCurrentToPrevious();
                RaisePropertyChanged("CurrentPosition");
            }
            public void MoveNext() {
                this.GetDefaultView().MoveCurrentToNext();
                RaisePropertyChanged("CurrentPosition");
            }
            public void MoveLast() {
                this.GetDefaultView().MoveCurrentToLast();
                RaisePropertyChanged("CurrentPosition");
            }
