     protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
            ExerciseType = (string)e.Parameter;
            Task<PlayerModel> playerProfile = App.player.GetPlayerProfilesAsync();
            PlayerModel player = await playerProfile;
            Level = player.Level;
            Life = player.Lives;
            if (Level == PlayerModel.LevelEnum.Difficult)
            {
                timePanel.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            playerLife.DataContext = player;
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            // Once clicked then disabled
            startButton.IsEnabled = false;
            // Enable buttons required for answering 
            resultTextBox.IsEnabled = true;
            submitButton.IsEnabled = true;
            // Change control settings depending on the level
            if (Level == PlayerModel.LevelEnum.Difficult)
            {
                // timer commands
                timer = new CountDownTimer();
                timer.StartCountDown();
                countdown.DataContext = timer;
                Random random = new Random();
                RandomNumber = random.Next(1, 3);
                var equation = App.equation.GenerateEquation(ExerciseType, RandomNumber);
                this.DataContext = equation;
                tempEquation = equation;
                //Randomly select an operator textbox to perform some actions
                if (RandomNumber == 1)
                {
                    equation.LeftOp = null;
                    leftOperand.IsEnabled = true;
                }
                else if (RandomNumber == 2)
                {
                    equation.RightOp = null;
                    rightOperand.IsEnabled = true;
                }
            }
            else if (Level == PlayerModel.LevelEnum.Easy)
            {
                RandomNumber = 0;
                var equation = App.equation.GenerateEquation(ExerciseType, RandomNumber);
                this.DataContext = equation;
                Result = App.equation.GetResult(equation);
            }
            // Reset message label
            if (message.Text.Length > 0)
            {
                message.Text = "";
            }
            // Reset result text box
            if (resultTextBox.Text.Length > 0)
            {
                resultTextBox.Text = "";
            }
        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.StopCountDown();
            submitButton.IsEnabled = false;
            resultTextBox.IsEnabled = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(resultTextBox.Text, "[^0-9]") || System.Text.RegularExpressions.Regex.IsMatch(rightOperand.Text, "[^0-9]") || System.Text.RegularExpressions.Regex.IsMatch(leftOperand.Text, "[^0-9]"))
            {
                timer.StopCountDown();
                MessageDialog msgDialog = new MessageDialog("Please enter only numbers.");
                //OK Button
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = OkBtnClick;
                msgDialog.Commands.Add(okBtn);
                msgDialog.ShowAsync();
                if (resultTextBox.Text.Length > 0)
                {
                    resultTextBox.Text.Remove(resultTextBox.Text.Length - 1);
                }
                
                //Reset buttons to answer again
                submitButton.IsEnabled = true;
                resultTextBox.IsEnabled = true;
            }
            else
            {
                try
                {
                    if (RandomNumber == 1)
                    {
                        int OpValue = Int32.Parse(leftOperand.Text);
                        tempEquation.LeftOp = OpValue;
                        Result = App.equation.GetResult(tempEquation);
                    }
                    else if (RandomNumber == 2)
                    {
                        int OpValue = Int32.Parse(rightOperand.Text);
                        tempEquation.RightOp = OpValue;
                        Result = App.equation.GetResult(tempEquation);
                    }
                    int userinput = Int32.Parse(resultTextBox.Text);
                    if (userinput == Result)
                    {
                        message.Text = "Bingo!";
                        //App.player.GainLifeAsync();
                        App.player.AnsweredCorrectlyAsync();
                        startButton.IsEnabled = true;
                        rightOperand.IsEnabled = false;
                        leftOperand.IsEnabled = false;
                    }
                    else
                    {
                        message.Text = "Wrong, sorry...";
                        //App.player.LoseLifeAsync();
                        App.player.AnsweredWronglyAsync();
                        startButton.IsEnabled = true;
                        rightOperand.IsEnabled = false;
                        leftOperand.IsEnabled = false;
                        rightOperand.Text.Remove(rightOperand.Text.Length - 1);
                        leftOperand.Text.Remove(leftOperand.Text.Length - 1);
                    }
                }
                catch (Exception ex)
                {
                    timer.StopCountDown();
                    MessageDialog msgDialog = new MessageDialog("Please type something first.");
                    //OK Button
                    UICommand okBtn = new UICommand("OK");
                    okBtn.Invoked = OkBtnClick;
                    msgDialog.Commands.Add(okBtn);
                    msgDialog.ShowAsync();
                    submitButton.IsEnabled = true;
                    resultTextBox.IsEnabled = true;
                }
            }
        }
        private void OkBtnClick(IUICommand command)
        {
            timer.StartCountDown();
        }
