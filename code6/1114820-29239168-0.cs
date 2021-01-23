    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace StackOverflow
    {
        [TestClass]
        public class IntegrationTest
        {
            [TestMethod]
            public void NotifyPropertyChangeShouldFireOnViewModelWhenModelChanges()
            {
                //Arrange
    
                Model model = new Model();
                ViewModel sut = new ViewModel(model);
                bool notifyPropertyChangeOnViewModelWasCalled = false;
                sut.PropertyChanged += (sender, e) => { notifyPropertyChangeOnViewModelWasCalled = true; };
    
                //Act
    
                model.CalcValue = 4711;
    
                //Assert
    
                Assert.IsTrue(notifyPropertyChangeOnViewModelWasCalled, "NotifyPropertyChange was not fired on ViewModel");
            }
        }
    
    
        public class ObjectWithNotifyPropertyChanged : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class Model : ObjectWithNotifyPropertyChanged
        {
            private double calcValue;
            public double CalcValue
            {
                get
                {
                    return calcValue;
                }
                set
                {
                    if (calcValue != value)
                    {
                        calcValue = value;
                        RaisePropertyChanged();
                    }
                }
            }
        }
    
        public class ViewModel : ObjectWithNotifyPropertyChanged
        {
            public ViewModel(Model model)
            {
                this.model = model;
                model.PropertyChanged += model_PropertyChanged;
            }
    
            void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case "CalcValue":
                        RaisePropertyChanged("CalcValue");
                        break;
                }
            }
    
            private Model model;
    
            public double CalcValue
            {
                get
                {
                    return model.CalcValue;
                }
            }
        }
    }
