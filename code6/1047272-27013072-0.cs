            for (int i = 0; i < objReceiptMaster.Count; i++)
            {
                var item = objReceiptMaster[i];
                if (item.application == "applicationname" && item.users.Any(x => x.surname == "surname"))
                    objReceiptMaster[i] = new ReceiptAllocationMaster();
            }
