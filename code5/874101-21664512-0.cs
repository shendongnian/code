    function NormalizeItemsArray() {
        var result = new Array();
    
        for (var i in items) {
            i = items[i];
            var item = new Item();
            item.ItemId = i.ItemId;
            item.Title = i.Title;
            item.Questions = new Array();
            
            for (var q in i.Questions) {
                q = i.Questions[q];
                var question = new Question();
                question.QuestionId = q.QuestionId;
                question.Description = q.Description;
                question.Values = new Array();
                
                for (var v in q.Values) {
                    v = q.Values[v];
                    var questionValue = new QuestionValue();
                    questionValue.ValueId = v.ValueId;
                    questionValue.Description = v.Description;
                    questionValue.IsCorrect = v.IsCorrect;
    
                    question.Values.push(questionValue);
                }
                item.Questions.push(question);
            }
            result.push(item);
        }
    
        return result;
    }
