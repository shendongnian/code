           private void SendInviteViaSMS(){
    
            var phoneNumberChooserTask= new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += PhoneNumberChooserTaskOnCompleted;
            phoneNumberChooserTask.Show();
        }
        private void PhoneNumberChooserTaskOnCompleted(object sender, PhoneNumberResult phoneNumberResult)
        {
            if (phoneNumberResult.TaskResult == TaskResult.OK)
            {
                Debug.WriteLine("The phone number for " + phoneNumberResult.DisplayName + " is " + phoneNumberResult.PhoneNumber);
                var smsComposeTask = new SmsComposeTask();
                smsComposeTask.To = phoneNumberResult.PhoneNumber;
                smsComposeTask.Body = String.Format(" Hey {0}, Try this new application. It's great!",phoneNumberResult.DisplayName);
                smsComposeTask.Show();
            }
        }
