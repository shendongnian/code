            var firstChild = elementList[0].FirstChild;
            elementList[0].Attributes.RemoveAll();
            for (int i = 0; i < firstChild.Attributes.Count; i++)
            {
                XmlAttribute item = doc.CreateAttribute(firstChild.Attributes[i].Name);
                item.Value = firstChild.Attributes[i].Value;
                elementList[0].Attributes.Append(item);
            }
            elementList[0].RemoveChild(firstChild);
