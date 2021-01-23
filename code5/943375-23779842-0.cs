    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
    
            string headerName;
            if (NavigationContext.QueryString.TryGetValue("goto", out headerName))
            {
    
                for (var i = 0; i < infra.Items.Count; i++)
                {
                    if (((PivotItem)infra.Items[i]).Header == headerName)
                    {
                        infra.SelectedIndex = i;
                        break;
                    }
                }
    
            }
            base.OnNavigatedTo(e);
        }
