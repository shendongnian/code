    // Shows a TangibleMenu element
    private void Show(TangibleMenu TangibleMenuElement)
    {
        App.Current.Dispatcher.Invoke(new Action(() =>
        {
            if (TangibleMenuElement.Shape.CheckAccess())
            {
                Debug.WriteLine("normal show");
                TangibleMenuElement.Shape.Opacity = 1;
                TangibleMenuElement.Shape.Visibility = System.Windows.Visibility.Visible;
                this.ParentContainer.Activate(TangibleMenuElement.Shape);
            }
            else
            {
                Debug.WriteLine("dispatcher show");
                TangibleMenuElement.Shape.Opacity = 1; // EXCEPTION HERE
                TangibleMenuElement.Shape.Visibility = System.Windows.Visibility.Visible;
                this.ParentContainer.Activate(TangibleMenuElement.Shape);
            }
        }));
    }
