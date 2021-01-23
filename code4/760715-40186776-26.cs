    namespace MyProject.Controllers
    {
        /// <summary>
        /// create SelectListItem from strings
        /// </summary>
        /// <param name="isValue">defaultValue is SelectListItem.Value is true, SelectListItem.Text if false</param>
        /// <returns></returns>
        private SelectListItem newItem(string value, string text, string defaultValue = "", bool isValue = false)
        {
            SelectListItem ss = new SelectListItem();
            ss.Text = text;
            ss.Value = value;
            // select default by Value or Text
            if (isValue && ss.Value == defaultValue || !isValue && ss.Text == defaultValue)
            {
                ss.Selected = true;
            }
            return ss;
        }
        /// <summary>
        /// this pulls the state name from _context and sets it as the default for the selectList
        /// </summary>
        /// <param name="myState">sets default value for list of states</param>
        /// <returns></returns>
        private SelectList getStateList(string myState = "")
        {
            List<SelectListItem> states = new List<SelectListItem>();
            SelectListItem chosen = new SelectListItem();
            // set default selected state to OHIO
            string defaultValue = "OH";
            if (!string.IsNullOrEmpty(myState))
            {
                defaultValue = myState;
            }
            try
            {
                states.Add(newItem("AL", "Alabama", defaultValue, true));
                states.Add(newItem("AK", "Alaska", defaultValue, true));
                states.Add(newItem("AZ", "Arizona", defaultValue, true));
                states.Add(newItem("AR", "Arkansas", defaultValue, true));
                states.Add(newItem("CA", "California", defaultValue, true));
                states.Add(newItem("CO", "Colorado", defaultValue, true));
                states.Add(newItem("CT", "Connecticut", defaultValue, true));
                states.Add(newItem("DE", "Delaware", defaultValue, true));
                states.Add(newItem("DC", "District of Columbia", defaultValue, true));
                states.Add(newItem("FL", "Florida", defaultValue, true));
                states.Add(newItem("GA", "Georgia", defaultValue, true));
                states.Add(newItem("HI", "Hawaii", defaultValue, true));
                states.Add(newItem("ID", "Idaho", defaultValue, true));
                states.Add(newItem("IL", "Illinois", defaultValue, true));
                states.Add(newItem("IN", "Indiana", defaultValue, true));
                states.Add(newItem("IA", "Iowa", defaultValue, true));
                states.Add(newItem("KS", "Kansas", defaultValue, true));
                states.Add(newItem("KY", "Kentucky", defaultValue, true));
                states.Add(newItem("LA", "Louisiana", defaultValue, true));
                states.Add(newItem("ME", "Maine", defaultValue, true));
                states.Add(newItem("MD", "Maryland", defaultValue, true));
                states.Add(newItem("MA", "Massachusetts", defaultValue, true));
                states.Add(newItem("MI", "Michigan", defaultValue, true));
                states.Add(newItem("MN", "Minnesota", defaultValue, true));
                states.Add(newItem("MS", "Mississippi", defaultValue, true));
                states.Add(newItem("MO", "Missouri", defaultValue, true));
                states.Add(newItem("MT", "Montana", defaultValue, true));
                states.Add(newItem("NE", "Nebraska", defaultValue, true));
                states.Add(newItem("NV", "Nevada", defaultValue, true));
                states.Add(newItem("NH", "New Hampshire", defaultValue, true));
                states.Add(newItem("NJ", "New Jersey", defaultValue, true));
                states.Add(newItem("NM", "New Mexico", defaultValue, true));
                states.Add(newItem("NY", "New York", defaultValue, true));
                states.Add(newItem("NC", "North Carolina", defaultValue, true));
                states.Add(newItem("ND", "North Dakota", defaultValue, true));
                states.Add(newItem("OH", "Ohio", defaultValue, true));
                states.Add(newItem("OK", "Oklahoma", defaultValue, true));
                states.Add(newItem("OR", "Oregon", defaultValue, true));
                states.Add(newItem("PA", "Pennsylvania", defaultValue, true));
                states.Add(newItem("RI", "Rhode Island", defaultValue, true));
                states.Add(newItem("SC", "South Carolina", defaultValue, true));
                states.Add(newItem("SD", "South Dakota", defaultValue, true));
                states.Add(newItem("TN", "Tennessee", defaultValue, true));
                states.Add(newItem("TX", "Texas", defaultValue, true));
                states.Add(newItem("UT", "Utah", defaultValue, true));
                states.Add(newItem("VT", "Vermont", defaultValue, true));
                states.Add(newItem("VA", "Virginia", defaultValue, true));
                states.Add(newItem("WA", "Washington", defaultValue, true));
                states.Add(newItem("WV", "West Virginia", defaultValue, true));
                states.Add(newItem("WI", "Wisconsin", defaultValue, true));
                states.Add(newItem("WY", "Wyoming", defaultValue, true));
                
                foreach (SelectListItem state in states)
                {
                    if (state.Selected)
                    {
                        chosen = state;
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                string ss = "ERR!   " + err.Source + "   " + err.GetType().ToString() + "\r\n" + err.Message.Replace("\r\n", "   ");
                ss = this.sendError("Online getStateList Request", ss, _errPassword);
                // return error
            }
            // .AsEnumerable() is not required in the pass.. it is an extension of Linq
            SelectList myList = new SelectList(states.AsEnumerable(), "Value", "Text", chosen);
            object val = myList.SelectedValue;
            return myList;
        }
        public ActionResult pickState(MyModel pData)
        {
            if (pData.StateList == null)
            {
                if (String.IsNullOrEmpty(pData.StatePick)) // state abbrev, value collected onchange
                {
                    pData.StateList = getStateList();
                }
                else
                {
                    pData.StateList = getStateList(pData.StatePick);
                }
                // assign values to state list items
                try
                {
                    SelectListItem si = (SelectListItem)pData.StateList.SelectedValue;
                    pData.state = si.Value;
                    pData.StatePick = si.Value;
                }
                catch { }
            } 
        return View(pData);
        }
    }
