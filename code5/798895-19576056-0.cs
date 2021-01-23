        colorList = new List<System.Drawing.Pen>();
        foreach (var field in typeof(System.Drawing.Color).GetFields())
        {
            if (field.FieldType.Name == "Color" && field.Name != null)
            {
                colorList.Add(new System.Drawing.Pen((Color)field.GetValue(null), (float)1));
            }
        }
