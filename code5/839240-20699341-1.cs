    private void MapLabels()
    {
        var labelsResult = string.Empty;
        var labelString = "123456789";
        for (int i = 0; i < labelString.Length; i++)
        {
            var control = this.FindControl("label" + labelString[i]);
            if(control != null)
            {
                labelsResult += ((Label)control).Text;
            }
        }
        labelResult1.Text = labelsResult;
    }
