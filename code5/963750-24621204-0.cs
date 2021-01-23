        //Force validation on each combobox2
        private void ValidateTrials()
        {
            foreach (IntroViewModel introVm in icTrials.Items)
            {
                ContentPresenter cp = (ContentPresenter)icTrials.ItemContainerGenerator.ContainerFromItem(introVm);
                if (cp == null) continue;
                ComboBox cb2 = (ComboBox)cp.ContentTemplate.FindName("cb2", (FrameworkElement)cp);
                //Update the source to force validation.
                cb2.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            }
        }
        //Recursively searches the Visual Tree for ComboBox elements and checks their errors state
        public bool TrialsHaveError(DependencyObject ipElement)
        {
            if (ipElement!= null)
            {
                for (int x = 0; x < VisualTreeHelper.GetChildrenCount(ipElement); x++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(ipElement, x);
                    if (child != null && child is ComboBox)
                    {
                        if (Validation.GetHasError(child))
                            return true;
                    }
                    if (TrialsHaveError(child)) return true;   //We found a combobox with an error
                }
            }
            return false;
        }
