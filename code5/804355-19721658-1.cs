            string GroupName = "MyGroupName"; // Your known group name
            List<RadioButton> radioButtonsOfSameGroup = new List<RadioButton>();
            var cntls = GetAll(this, typeof(RadioButton));
            foreach (Control cntrl in cntls)
            {
                RadioButton rb = (RadioButton)cntrl;
                if (rb.GroupName == GroupName)
                {
                    radioButtonsOfSameGroup.Add(rb);
                }
            }
            int numberOfRadioOfThisGroup = radioButtonsOfSameGroup.Count();
