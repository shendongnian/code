    public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
            {
                    FrameworkElement element = container as FrameworkElement;
                    if (item != null && container != null)
                {
                    if (item is CentralPrintUnitSystem.Dialogs.EditNewEntryDialogView)
                {
                    return element.FindResource("EditNewEntryDataTemplate") as DataTemplate;
                }
                    if (item is   CentralPrintUnitSystem.Dialogs.EditNewDepartmentDialogView)
                {
                    return element.FindResource("CreateNewDepartmentDataTemplate") as DataTemplate;
                }
                else
                {
                    return null;
                }
                return null;
                }
            return null;
            }
