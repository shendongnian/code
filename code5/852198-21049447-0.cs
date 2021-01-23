            var SourceEnumList = new List<string>();
            if (checkBox_WebPortal.Checked)
            {
                SourceEnumList.Add("WebPortal");
            }
            if (checkBox_SubService.Checked)
            {
                SourceEnumList.Add("SubService");
            }
            if (checkBox_TruckRouting.Checked)
            {
                SourceEnumList.Add("TruckRouting");
            }
            if (checkBox_SuburbanHub.Checked)
            {
                SourceEnumList.Add("SuburbanHub");
                
            }
            if (SourceEnumList.Any())
            {
                qry = qry.Where(x => SourceEnumList.Contains(x.SourceEnum) );
            }
