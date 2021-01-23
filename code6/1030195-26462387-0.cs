        /// <summary>
        /// Returns all children elements of an automation element.
        /// </summary>
        public virtual List<AutomationElement> GetAllAutomationElements(AutomationElement aeElement)
        {
            AutomationElement aeFirstChild = TreeWalker.RawViewWalker.GetFirstChild(aeElement);
            List<AutomationElement> aeList = new List<AutomationElement>();
            aeList.Add(aeFirstChild);
            AutomationElement aeSibling = null;
            int count = 0;
            while ((aeSibling = TreeWalker.RawViewWalker.GetNextSibling(aeList[count])) != null)
            {
                aeList.Add(aeSibling);
                count++;
            }
            return aeList;
        }
