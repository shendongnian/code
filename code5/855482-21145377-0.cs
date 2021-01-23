        //code that removes data from list starts from here
        List<PointF> pointsToRemove = new List<PointF>();
        float[] difference = new float[points.Count()];
        for (int i = 0; i <= points.Count(); i++) 
        {
            for (int j = 1; j <= points.Count(); j++) 
            {
                difference[j] = sumofxandy[i] - sumofxandy[j];
                if (difference[i] != 0) 
                {
                    pointsToRemove.Add(points[j]);
                    MessageBox.Show("removed");
                }
            }
        }
        listBox2.DataSource = points.Except(pointsToRemove).ToList();
