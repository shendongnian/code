    var attachmentDetails = (from a in AttachmentsService.FindAllAttachments().Attachments
                                 join ut in UserTicketsService.FindAllUserTickets().UserTickets on a.UserTicketId equals ut.Id into aut
                                 from ut in aut.DefaultIfEmpty()
                                 join t in TicketsService.FindAllTickets().Tickets on ut.TicketId equals t.Id into utt
                                 from t in utt.DefaultIfEmpty()
                                 where a.ItemKey.ToUpper() == userName.ToUpper() 
                                 select new UserTicketsViewModel
                                 {
                                     AttachmentId = a.Id,
                                     FilePath = a.FileName,
                                     TicketName=t!=null?t.TicketName:"",
                                     FileName = a.FileName,
                                     UserId = UserId,
                                 }).ToList();
    foreach (var item in attachmentDetails)
        item.FileName = Path.GetFileName(item.FileName);
