            var filter1 = new Filter("description", new List<string> { "*SUSE*" });
            var req = new DescribeImagesRequest();
            req.Filters.Add(filter1);
            req.Owners.Add("amazon");
            var imgs = ec2Client.DescribeImages(req);
            foreach(Amazon.EC2.Model.Image img in imgs.Images)
            {
                Console.WriteLine(img.Name + " , " + img.ImageId + " , " + img.Description + " , " + img.Platform + " , " + img.Architecture);
            }
