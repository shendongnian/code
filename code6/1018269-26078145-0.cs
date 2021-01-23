            string s = "(1,2)(2,3)(3,4)(4,5)";
            var rawPieces = s.Split(')');
            var container =  new List<System.Drawing.Point>();
            foreach(var coordinate in rawPieces)
            {
                var workingCopy = coordinate.Replace("(",String.Empty).Replace(")",String.Empty);
                if(workingCopy.Contains(","))
                {
                    var splitCoordinate = workingCopy.Split(',');
                    if(splitCoordinate.Length == 2)
                    {
                        container.Add(new System.Drawing.Point(Convert.ToInt32(splitCoordinate[0]),Convert.ToInt32(splitCoordinate[1])));
                    }
                }
            }
            Console.WriteLine(container.Count);
