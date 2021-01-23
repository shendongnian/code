            foreach (var node in xd.Document
                .Element("MCBuddy")
                .Element("MCScript")
                .Elements())
            {
                var ele = (XElement) node;
                switch (ele.Name.ToString())
                {
                    case "Status":
                        mb_statusLabel.Text = ele.Value;
                        break;
                    case "CameraMove":
                        var move = new Point(
                            Cursor.Position.X + Convert.ToInt32(ele.Attribute("X").Value),
                            Cursor.Position.Y + Convert.ToInt32(ele.Attribute("Y").Value));
                        TimeSpan moveTime = new TimeSpan(0, 0, 0, 1);
                        LinearSmoothMove(move, moveTime);
                    break;
                        // others go here
                    default:
                        Trace.WriteLine(ele.Name);
                        break;
                }
            }
