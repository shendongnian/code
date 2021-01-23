    private async void btnAddShots_Click(object sender, EventArgs e)
    {
        int noOfShots = dataGridShots.Rows.Count - 1;
        int count = 0;
        while (count < noOfShots)
        {
            await addTaskPair(dataGridShots.Rows[count].Cells[0].Value.ToString(), 
                dataGridShots.Rows[count].Cells[1].Value.ToString(), 
                dataGridShots.Rows[count].Cells[2].Value.ToString());
            count += 1;
        }
    }
    private async Task addTaskPair(string taskName, string taskDescription, string taskPriority)
    {
        try
        {
            TaskData trackingTask = new TaskData();
    
            trackingTask.content = taskName;
            trackingTask.description = taskDescription;
            trackingTask.priority = taskPriority; 
    
            string trackingJson = JsonConvert.SerializeObject(trackingTask);
            trackingJson = "{ \"todo-item\":" + trackingJson + " }";
    
            string jsonResponse;
            string url = teamworkURL + "/tasklists/" 
                + todoLists.todoLists[cmbTrackingList.SelectedIndex].id + "/tasks.json";
            jsonResponse = await Task.Run(() => postJSON(trackingJson, url));
        }
        catch (Exception e)
        {
            debugMessage(e.ToString());
        }
    }
