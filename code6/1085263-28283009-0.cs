    @using System.Linq
    @using System
    @using System.Text
    @using System.Collections;
    @model List<PairingTest.Web.Models.QuestionnaireViewModel>
    
    <html>
    <head>
        <title></title>
    </head>
    <body>
    @using (Html.BeginForm("GetMarks","Questionnaire")) {
    
    
        for(int i = 0;i < Model.Count;i++) {
    
            @Model[i].QuestionAsk <br />
    
            var s = Model[i].PossibleAnswer;
            string[] exAns = s.Split(',');
    
            foreach( var singleAns in exAns){
             @singleAns <br />
             @Html.RadioButtonFor(M =>M[i].UserAnsResponse, singleAns) <br />
            }
    
            <br />
        }
    
      <input type="submit" name="submit" />
    }  
    </body>
