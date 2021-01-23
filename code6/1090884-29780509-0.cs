            //change your range
            Range range = worksheet.UsedRange;
            //this part makes all the in-range rows of first column as a dropdown list
            int row;
            for (row = 1; row <= range.Rows.Count; row++)
            {
                xlDropDowns = ((DropDowns) (worksheet.DropDowns(Type.Missing)));
                xlDropDown = xlDropDowns.Add((double) range[row, 1].Left, (double) range[row, 1].Top,
                    (double) range[row, 1].Width, (double) range[row, 1].Height, true);
                string[] ddl_item =
                {
                    "Answers",
                    "Autos",
                    "Finance",
                    "Games",
                    "Groups",
                    "HotJobs",
                    "Maps",
                    "Mobile Web",
                    "Movies",
                    "Music",
                    "Personals",
                    "Real Estate",
                    "Shopping",
                    "Sports",
                    "Tech",
                    "Travel",
                    "TV",
                    "Yellow Pages"
                };
                for (int i = 0; i < ddl_item.Count(); i++)
                {
                    xlDropDown.AddItem(ddl_item[i], i + 1);
                }
            }
