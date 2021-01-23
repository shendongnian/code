            queueWebRequest = new Queue<Request>();
    
            for (int i = 0; i < imageCollection.Count; i++)
            {
                queueWebRequest.Enqueue(new Request(imageCollection[i].ImageTag));
              
            }
            for (int i = 0; i < imageCollection.Count; i++)
            {
                if (queueWebRequest.Count > 0)
                {
                    Request currentRequest = queueWebRequest.Dequeue();
                    await currentRequest.MakeAsyncRequest();
                    imageCollection[i].ImageDescription = currentRequest.imageDesc;
                }
                else
                    break;
            }
 
