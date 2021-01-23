    public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Sensor Name can not be empty.");
                }
                if (value.Length > 12)
                {
                    throw new Exception("Sensor name can not be longer than 12 charectors");
                }
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
     
