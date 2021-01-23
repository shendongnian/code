    public class VehicleViewModel:ViewModelBase
        {
            private bool isCar, isTrain, isBus;
            public bool IsCar
            {
                get { return isCar; }
                set
                {
                    if (isCar == value) return;
                    isCar = value;
                    OnChanged("IsCar");
                }
            }
            public bool IsTrain
            {
                get { return isTrain; }
                set
                {
                    if (isTrain == value) return;
                    isTrain = value;
                    OnChanged("IsTrain");
                }
            }
            public bool IsBus
            {
                get { return isBus; }
                set
                {
                    if (isBus == value) return;
                    isBus = value;
                    OnChanged("IsBus");
                }
            }
        }
