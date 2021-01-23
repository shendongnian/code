    using Pechkin;
    using Pechkin.Synchronized;
    public ActionResult ToPdf(int id)
    {
    var order = _orderBll.GetById(id);
    var viewHtml = order.Body;
    byte[] pdfBuf = new SynchronizedPechkin(new GlobalConfig()).Convert(viewHtml);
    return File(pdfBuf, "application/pdf");
    }
