                private string fname;
        
                public string FirstName
                {
                    get { return fname; }
                    set { fname = value;RaisePropertyChanged("FirstName"); }
                }
        
                private string sname;
        
                public string SecondName
                {
                    get { return sname; }
                    set { sname = value; RaisePropertyChanged("SecondName");}
                }
        
                private string company;
        
                public string Company
                {
                    get { return company; }
                    set { company = value;RaisePropertyChanged("Company"); }
                }
        
        
                public event PropertyChangedEventHandler PropertyChanged;
                private void RaisePropertyChanged(string name)
                {
                    if(PropertyChanged!= null)
                    {
                        this.PropertyChanged(this,new PropertyChangedEventArgs(name));
                    }
                }
            }
