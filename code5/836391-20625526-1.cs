    protected void trainingDataList_ItemCommand(object source, 
                                                DataListCommandEventArgs e)
    {
        List<Material> dataset = null;
        var theButton = trainingDataList.Items[e.Item.ItemIndex]
                                        .FindControl("btnQuizVid") as Button;
       
        if (e.CommandName == "quiz")
        {
            dataset = BasicCRUDtoolkit.GetMaterialByProfFocus(hdnTypeSelect.Value);
        
            if (theButton.Text == "Quiz")
            {
                theButton.Text = "Video";
                dataset[e.Item.ItemIndex].videoURL = dataset[e.Item.ItemIndex].quizURL;
            }
            else
            {
                theButton.Text = "Quiz";
                dataset[e.Item.ItemIndex].videoURL = dataset[e.Item.ItemIndex].videoURL;
            }
            trainingDataList.DataSource = dataset;
            trainingDataList.DataBind();
        }
    }
