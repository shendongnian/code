    [WebMethod]
    [System.Xml.Serialization.XmlInclude(typeof(Object[]))]
    public ArrayList ReceiveMessage(string strUser)
    {
        ArrayList arrList = new ArrayList();
        for (int i = 0; i < arrMessage.Count; i++)
        {
            object[] objArr = (object[])arrMessage[i];
            if (objArr[1].ToString() == strUser)
            {
                arrList.Add(new object[] { objArr[0], objArr[2], objArr[3], objArr[4] });
                arrMessage.RemoveAt(i);
                break;
            }
        }
        return arrList;
    }
