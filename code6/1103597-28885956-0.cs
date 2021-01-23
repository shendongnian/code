    public class Message
        {
            public string Title { get; set; }
            public string Mensagem { get; set; }
            public List<string> Itens { get; set; }
            public string itensRetorno { get; set; }
    
            public Message()
            {
                this.Itens = new List<string>();
            }
    
            public void Add(string item)
            {
                this.Itens.Add(item);
            }
    
            public string GetMessages()
            {
                var MsgItens = string.Empty;
    
                foreach (var item in this.Itens)
                {
                    MsgItens += "<li>" + item + "</li>";
                }
    
                this.itensRetorno = MsgItens;
    
                return MsgItens;
            }
    
    
    public static class ModelStateUtils
        {
            public static Message GetModelStateErrors(ModelStateDictionary modelState)
            {
                Message msg = new Message();
    
                List<string> errorKeys = new List<string>();
    
                int index = 0;
    
                foreach (var val in modelState.Values)
                {
                    if (val.Errors.Count() > 0)
                    {
                        msg.Itens.Add(modelState.Keys.ElementAt(index));
                    }
    
                    index++;
                }
    
                msg.Title = "Erro";
                msg.Mensagem = "Os seguintes campos são obrigatórios<br />" + msg.GetMessages();
    
                return msg.Itens.Count() > 0 ? msg : null;
            }
        }
