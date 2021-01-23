    foreach (ProjectStatistic PR in repository.GetProjectByRAG())
            {
                int index = ProjectsByProjectTypePieChart.Series["series"].Points.AddXY(PR.Name, PR.Value);
                if (PR.Name == "Green")
                { 
                    ProjectsByProjectTypePieChart.Series["series"].Points[index].Color = System.Drawing.Color.Green;
                }
                if (PR.Name == "Amber")
                {
                    ProjectsByProjectTypePieChart.Series["series"].Points[index].Color = System.Drawing.Color.Yellow;
                }
                if (PR.Name == "Red")
                {
                    ProjectsByProjectTypePieChart.Series["series"].Points[index].Color = System.Drawing.Color.Red;
                }
            }
