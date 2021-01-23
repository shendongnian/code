        if (this.Question == 10)
                {
                    SummaryofDrivingTest form = new SummaryofDrivingTest(this.lblName.Text, this.Gender, this.DOB, this.Address, this.Postcode, this.Phone, this.Email, Convert.ToString(this.correct));
                    form.Show();
                    this.Hide();
    
    List<Quiz> dictionary;
            dictionary = new Dictionary<int, Quiz>();
            dictionary.Add(new Quiz("A vehicle should not send out visible smoke for more than?", "12 seconds", "10 seconds", "20 seconds", "5 seconds", "10 seconds"));
            dictionary.Add(new Quiz("Who can require you to undergo a breath screening test?", "An ambulance driver", "Other drivers", "Fire Crew", "A police officer", "A police officer"));
            dictionary.Add(new Quiz("When passing a bus displaying a School sign that has stopped to let children on or off, what should your speed be?", "20kph", "50kph", "70kph", "100kph", "20kph"));
            dictionary.Add(new Quiz("What is the speed limit from the time you pass an Accident sign until you have passed the crash site?", "30kph", "45kph", "25kph", "20kph", "20kph"));
            dictionary.Add(new Quiz("If your car was first registered before 1 January 2000, how often must you renew its warrant of fitness?", "Three Months", "Six Months", "Tweleve Months", "Twenty four Months", "Six Months"));
            dictionary.Add(new Quiz("What should you do when another vehicle is following you very closely?", "Move to the left and slow down to make it easier for it to pass", "Speed up so you're not holding it up", "Pump your brakes to tell them to drop back", "Put your hazard lights on", "Move to the left and slow down to make it easier for it to pass"));
            dictionary.Add(new Quiz("If you are driving a car, what should you do when following another vehicle in wet conditions?", "Observe the two-second rule", "Observe the four-second rule", "Observe the six-second rule", "Try to overtake so that you are not blinded by the spray", "Observe the four-second rule"));
            dictionary.Add(new Quiz("How many demerit points do you receive for exceeding the speed limit by 11-20kph?", "10", "20", "30", "40", "20"));
            dictionary.Add(new Quiz("If there are one or more yellow flashing lights at traffic signals, what does it mean?", "All cars must stop as emergency vehicles are coming through", "The lights are faulty and the Give Way rules apply", "There's a diversion ahead", "Move to the left hand side of the road", "The lights are faulty and the Give Way rules apply"));
            dictionary.Add(new Quiz("When passing a horse and rider, what should you do?", "Give a quick toot of the horn to warn them you're coming", "Pass as quickly as possible to avoid spooking the horse", "Slow down, giving them as much room as you can", "Turn on your headlights to warn the rider", "Slow down, giving them as much room as you can"));
            this.questions = dictionary;
    
                    return;
                }
