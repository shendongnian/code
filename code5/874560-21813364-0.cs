    using AutomationUtils;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Automation;
    namespace GenericUIAutomation
    {
    class ElementTree
    {
        private AutomationElement current;
        private List<ElementTree> children = new List<ElementTree>();
        private List<String> ancestorNames = new List<String>();
        private static TestLog ofl;
        public ElementTree(TestLog testlog)
        {
            ofl = testlog;
            this.current = AutomationElement.RootElement;
            //This is the root element, no ancestors.
            ancestorNames = null;
            AutomationElementCollection childrenTemp = current.FindAll(TreeScope.Children, System.Windows.Automation.Condition.TrueCondition);
            children.Capacity = childrenTemp.Count;
            List<String> childrenAncestors = new List<String>();
            childrenAncestors.Add(this.current.Current.Name);
            foreach (AutomationElement child in childrenTemp)
                children.Add(new ElementTree(child, childrenAncestors));
            childrenTemp = null;
        }
        public ElementTree(AutomationElement current, List<String> ancestorList)
        {
            this.current = current;
            this.ancestorNames = ancestorList;
            AutomationElementCollection childrenTemp = current.FindAll(TreeScope.Children, System.Windows.Automation.Condition.TrueCondition);
            children.Capacity = childrenTemp.Count;
            List<String> childrenAncestors = new List<String>();
            childrenAncestors.AddRange(ancestorList);
            childrenAncestors.Add(this.current.Current.Name);
            foreach (AutomationElement child in childrenTemp)
                children.Add(new ElementTree(child, childrenAncestors));
            childrenTemp = null;
        }
        public ElementTree FindInTree(String name, ControlType controlType, String[] ancestorList)
        {
            String ct = "IGNORE";
            if (controlType != null)
                ct = controlType.LocalizedControlType.ToString();
            ofl.AddLine("Scanning for \"" + name + "\" - " + " Control Type: " + ct);
            ElementTree res = FindInTreeIMP(name, controlType, ancestorList);
            if (res != null)
                ofl.AddLine("Success! Found element \"" + res.GetName() + "\" - " + res.GetAutomationElement().Current.ControlType.LocalizedControlType);
            else
                ofl.AddLine("Error! No matching element found.");
            return res;
        }
        public ElementTree FindInTreeIMP(String name, ControlType controlType, String[] ancestorList)
        {
            ofl.AddLine("Scanning element \"" + current.Current.Name + "\" - " + current.Current.ControlType.LocalizedControlType);
            Boolean found = CompareElements(name, controlType, ancestorList);
            if (found)
                return this;
            foreach (ElementTree child in children)
            {
                ElementTree res = child.FindInTreeIMP(name, controlType, ancestorList);
                if (res != null)
                    return res;
            }
            return null;
        }
        private Boolean CompareElements(String name, ControlType controlType, String[] ancestorList)
        {
            Boolean found = false;
            //name should be contained in expected element name
            if (this.current.Current.Name.Contains(name))
            {
                PrintToLog("Name match found");
                found = true;
            }
            //Test for control type, if needed
            if (found == true && controlType != null)
            {
                PrintToLog("Control Type match found");
                if (this.current.Current.ControlType.CompareTo(controlType) != 0)
                    found = false;
            }
            if (found == true && this.ancestorNames.Count >= ancestorList.Length)
            {
                PrintToLog("Searching for Ancestors");
                found = CheckAncestors(ancestorList);
            }
            else
                found = false;
            return found;
        }
        private Boolean CheckAncestors(String[] ancestorList)
        {
            Boolean found = false;
            foreach (String ancestorName in ancestorList)
            {
                PrintToLog("Scanning for ancestor " + ancestorName);
                foreach (String ancestorListElement in ancestorList)
                    if (ancestorListElement.Contains(ancestorName))
                    {
                        PrintToLog("Found ancestor " + ancestorListElement);
                        found = true;
                        break;
                    }
                if (found != true)
                    return found;
                else
                    continue;
                
            }
            return found;
        }
        public String PrintTree()
        {
            return "\n" + PrintTree("");
        }
        public String PrintTree(String preText)
        {
            String self = preText + GetExtendedInfo();
            foreach (ElementTree child in children)
                self += "\n" + preText + child.PrintTree(preText + "   |");
            return self;
        }
        public AutomationElement GetAutomationElement()
        {
            return current;
        }
        public String GetName()
        {
            return current.Current.Name;
        }
        public String GetExtendedInfo()
        {
            int childrenCount = 0;
            int ancestorsCount = 0;
            String name = current.Current.Name;
            String controlType = current.Current.ControlType.LocalizedControlType;
            if (children != null)
                childrenCount = children.Count;
            if (ancestorNames != null)
                ancestorsCount = ancestorNames.Count;
            return "\"" + name + "\" - " + controlType + " - " + childrenCount + " Children" + " - " + ancestorsCount + " Ancestors";
        }
        public void PrintToLog(String text)
        {
            ofl.AddLine(text);
        }
    }
    }
