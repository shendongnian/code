    class Program
        {
            static void Main(string[] args)
            {
                const string s = "[王萍 发送给您的,〈勘测设计校审卡流程〉 FA02571E3S-大唐哈尔滨第一热电厂采暖系统改造工程-[N0101]卸煤沟采暖施工图 业务|EcaClient:Cmd=OpenTask&TaskGuid={5278BE74-E1A4-4B8D-9764-B543405634A7}&UserID=178&Sender=187]";
    
                if (s.IndexOf("〈") != -1)
                {
                    Console.Write("string contains '〈'");
                }
                Console.ReadLine();
            }
        }
