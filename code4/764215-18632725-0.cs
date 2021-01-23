    <table>
    //due to the table tag, we are current inside HTML 
    //so we need to use the @ symbol to move back to razor syntax
    @foreach (Message userMessage in UserMessages)
    {                               
        <tr>
        //using this tag again changes us back to HTML mode
        //so again we must use the at symbol
        @if(userMessage.Message.MessageText.Length <= 10)
        {
            //still Razor
            <td>
            //back in HTML mode
                 @userMessage.Message.MessageText
            </td>
        }
        @if(userMessage.Message.MessageText.Length > 10)
        {
            <td>
                 @userMessage.Message.MessageText.Substring(0, 10)
            </td>
        }    
        </tr>        
    }
    </table>
