           IList<SelectListItem> SelectedOptions = new List<SelectListItem>();
            IList<Options> DropDownOptions = new List<Options>();
            //Add items to this shipping
            foreach (var item in DropDownOptions)
            {
                SelectListItem sliItem = new SelectListItem();
                string optionText = item._name;
                sliItem.Value = item._value.ToString();
                sliItem.Text = optionText;
                SelectedOptions.Add(sliItem);
            }
            ViewData["Option"] = SelectedOptions;
