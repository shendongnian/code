        static ElementId Offset(this Element originalelement, double offsetamount, string offsetdirection)
        {
            ElementId newelement = null;
            Document curdoc = originalelement.Document;
            LocationPoint elp = originalelement.Location as LocationPoint;
            XYZ elem_location = null;
            
            switch(offsetdirection.ToUpper())
            {
                default:
                    break;
                case "X":
                    elem_location = new XYZ(offsetamount, 0.0, 0.0) + elp.Point;
                    break;
                case "Y":
                    // code for Y
                    break;
                case "Z":
                    // code for Z
                    break;
            }
            try
            {
                using (Transaction tr_offset = new Transaction(curdoc, "Offsetting element"))
                {
                    tr_offset.Start();
                    newelement = ElementTransformUtils.CopyElement(curdoc, originalelement.Id, elem_location).FirstOrDefault();
                    tr_offset.Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Command Failed. See below: \n" + e.StackTrace.ToString());
            }
            return newelement;
        }
