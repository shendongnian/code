                        public override bool IsNoOverTimeLimit(Reservation reservation)
                        {
                            return reservation.End.Subtract(reservation.Start).TotalMinutes <= 120;
                        }
                        if(!IsNoOverTimeLimit)
                        {
                            var errorMsg = new Label();
                            var fontSize = FontUnit.Point(10);
                            errorMsg.Font.Size = fontSize;
                            errorMsg.Text = "Reservation time is limited to " + ((float)30 / 60).ToString(CultureInfo.InvariantCulture) + " hours at a time.<br /> ";
                            placeHolder.Controls.Add(errorMsg);
                        }
