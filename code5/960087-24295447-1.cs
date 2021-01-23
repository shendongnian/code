    foreach (object item in taskslistBox.Items)
    {
        var listBoxItem = taskslistBox.ItemContainerGenerator.ContainerFromItem(item);
        var myContentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);
        var myDataTemplate = myContentPresenter.ContentTemplate;
        var mydata = (Label)myDataTemplate.FindName("tasklabel", myContentPresenter);
        var xmlElement = (XmlElement)mydata.Content;
        MessageBox.Show("element " + xmlElement.InnerText);
    }
