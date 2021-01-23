            var checkBoxes = new CheckBox[0];
            for (int i = 0; i <= 8005; i++)
            {
                var checkBox = new CheckBox(this);
                checkBox.Text = "your phrase";
                checkBox.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                parentLayout.AddView(checkBox);
                Array.Resize(ref checkBoxes, i + 1);
                checkBoxes[i] = checkBox;
            }
