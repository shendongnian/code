    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        //clear the update panel
        UpdatePanel1.Controls.Clear();
        //var to generate unique div id's 
        int divIDIncrement = 0;
        foreach (var t in OnlineTrainList)
        {
            //increment the id generator 
            divIDIncrement++;
            // create a a DIV element
            HtmlGenericControl _tempDIV = new HtmlGenericControl("div");
            //set the attributes for the div
            _tempDIV.ID = "train-box" + divIDIncrement.ToString();
            _tempDIV.Style["margin-left"] = (t.XTrainLocation - 8).ToString() + "px";
            _tempDIV.Style["margin-top"] = t.YTrainLocation.ToString() + "px";
            _tempDIV.Style["background"] = t.Train.TrainColor.ToString();
            //create the inner span
            HtmlGenericControl _tempSPAN = new HtmlGenericControl("span");
            //set the span's innerText
            _tempSPAN.InnerText = t.TrainId.ToString();
            //add the span into the Div
            _tempDIV.Controls.Add(_tempSPAN);
            //add the Div into your UpdatePanel
            UpdatePanel1.Controls.Add(_tempDIV);
    
    
            List<Sensor> PassedSensor = new List<Sensor>();
            PassedSensor = SensorRepository.FindBy(i => i.CurrentTrainId == t.TrainId).ToList();
            string color = TrainRepository.FindBy(i => i.Id == t.TrainId).First().TrainColor;
            foreach (Sensor sensor in PassedSensor)
            {
                // create another div for the sub stuff
                HtmlGenericControl _tempSubDIV = new HtmlGenericControl("div");
                _tempSubDIV.Attributes["class"] = "CurrentColor-Sensor";
                _tempSubDIV.Style["margin-left"] = (sensor.XLocation - 1).ToString() + "px";
                _tempSubDIV.Style["margin-top"] = (sensor.YLocation + 8).ToString() + "px";
                _tempSubDIV.Style["background"] = color.ToString();
                //add the sub stuff to the update panel
                UpdatePanel1.Controls.Add(_tempSubDIV);
            }
        } 
    }
