    chkIncident.SetBinding(CheckBox.IsCheckedProperty, 
                           new Binding("IncidentBuilderProperty.IsEnabled"));
    chkProblem.SetBinding(CheckBox.IsCheckedProperty, 
                           new Binding("ProblemBuilderProperty.IsEnabled"));
    chkService.SetBinding(CheckBox.IsCheckedProperty, 
                           new Binding("ServiceRequestBuilderProperty.IsEnabled"));
    ...
