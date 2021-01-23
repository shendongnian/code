    [WebMethod]
    public List<object> ReceiveMessage(string strUser)
    {
        List<object> list = new List<object>();
        for (int i = 0; i < arrMessage.Count; i++)
        {
            object[] objArr = (object[])arrMessage[i];
            if (objArr[1].ToString() == strUser)
            {
                list.Add(new object[] { objArr[0], objArr[2], objArr[3], objArr[4] });
                arrMessage.RemoveAt(i);
                break;
            }
        }
        return list;
    }
