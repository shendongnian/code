            var updSubTopic = new List<ObjectiveDetail>();
            newObj.ForEach(x => 
            {
                var comOld = oldObj.Where(y => x.ObjectiveDetailId == y.ObjectiveDetailId).FirstOrDefault();//You might want to add more conditions here
                if (comOld != null && x.SubTopics.Any(y => comOld.SubTopics.Where(z => y.SubTopicId == z.SubTopicId).Any(a => !a.Name.Equals(y.Name))))
                {
                    updSubTopic.Add(x);
                }
            });
