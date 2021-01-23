    static void Main(string[] args)
    {
        //the database
        var ObjectiveDetails = new List<ObjectiveDetail>()
        {
            new ObjectiveDetail()
            {
                ObjectiveDetailId = 1,
                Number = 1,
                Text = "datafromdb",
                SubTopics = new List<SubTopic>()
                {
                    new SubTopic(){ SubTopicId = 1, Name="one"}, //no change
                    new SubTopic(){ SubTopicId = 2, Name="two"}, //to be deleted
                    new SubTopic(){ SubTopicId = 4, Name="four"} //to be updated
                }
            }
        };
        //the object comes as json and serialized to defined object.
        var web = new ObjectiveDetail()
        {
            ObjectiveDetailId = 1,
            Number = 1,
            Text = "datafromweb",
            SubTopics = new List<SubTopic>()
            {
                new SubTopic(){ SubTopicId = 1, Name="one"}, //no change
                new SubTopic(){ SubTopicId = 3, Name="three"}, //new row
                new SubTopic(){ SubTopicId = 4, Name="new four"} //must be updated
            }
        };
        var objDet = ObjectiveDetails.FirstOrDefault(x => x.ObjectiveDetailId == web.ObjectiveDetailId);
        if (objDet != null)
        {
            //you can use AutoMapper or ValueInjecter for mapping and binding same objects
            //but it is out of scope of this question
            //update ObjectDetail
            objDet.Number = web.Number;
            objDet.Text = web.Text;
            var subtops = objDet.SubTopics.ToList();
            
            //Delete removed parameters from database
            //Entity framework can handle it for you via change tracking
            //subtopicId = 2 has been deleted 
            subtops.RemoveAll(x => !web.SubTopics.Select(y => y.SubTopicId).Contains(x.SubTopicId));
            
            //adds new items which comes from web
            //adds subtopicId = 3 to the list
            var newItems = web.SubTopics.Where(x => !subtops.Select(y => y.SubTopicId).Contains(x.SubTopicId)).ToList();
            subtops.AddRange(newItems);
            //this items must be updated
            var updatedItems = web.SubTopics.Except(newItems).ToList();
            
            foreach (var item in updatedItems)
            {
                var dbItem = subtops.First(x => x.SubTopicId == item.SubTopicId);
                dbItem.Name = item.Name;
            }
          
            //let's see is it working
            Console.WriteLine("{0}:\t{1}\t{2}\n---------",objDet.ObjectiveDetailId, objDet.Number, objDet.Text);
            foreach (var item in subtops)
            {
                Console.WriteLine("{0}: {1}", item.SubTopicId, item.Name);
            }
        }
        else
        {
             //insert new ObjectiveDetail
        }
        //In real scenario after doing everything you need to call SaveChanges or it's equal in your Unit of Work.
    }
