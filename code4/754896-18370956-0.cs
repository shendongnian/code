    private void getObjectiveCompletedHandler(object sender, getObjectiveCompletedEventArgs e)
        {
          List<string> namesList = new List<string>();
          foreach (string name in e.Result)
           {
            namesList.Add(name);
           }
        }
