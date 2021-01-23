        /// <summary>
        /// Add a list of CustomLabel to X Axis
        /// </summary>
        /// <param name="customLabelList">List of custom label</param>
        /// <param name="chartArea">Destination ChartArea</param>
        /// <param name="tag">Tag tha unique identify the custom label list</param>
        /// <param name="rowIndex"></param>
        public void AddAxisXCustomLabel(List<CustomLabel> customLabelList, string chartArea, string tag,int rowIndex)
        {
            foreach (CustomLabel cl in customLabelList)
            {
                cl.RowIndex = rowIndex;
                cl.Tag = tag;
                chart.ChartAreas[chartArea].AxisX.CustomLabels.Add(cl);
            }
        }
        /// <summary>
        /// Remove custom label from a list of custom label
        /// </summary>
        /// <param name="chartArea">Destination ChartArea</param>
        /// <param name="tag">Tag tha unique identify the custom label list</param>
        public void RemoveCustomLabelByTag(string chartArea,string tag)
        {
            for (int i = (chart.ChartAreas[chartArea].AxisX.CustomLabels.Count-1); i > -1; --i)
            { 
                CustomLabel cl = chart.ChartAreas[chartArea].AxisX.CustomLabels[i];
                if (cl.Tag.Equals(tag))
                {
                    chart.ChartAreas[chartArea].AxisX.CustomLabels.RemoveAt(i);
                }
            }
         }
