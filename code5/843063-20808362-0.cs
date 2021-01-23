    String maskedCardNumber = null;
    var qs = HttpUtility.ParseQueryString(request);
    var cardNumber = qs.Get("cardnumber");
    if (cardNumber != null)
    {
        var substring = cardNumber.Substring(cardNumber.Length - Math.Min(4, cardNumber.Length));
        maskedCardNumber = String.Format("XXXX-XXXX-XXXX-{0}", substring);
    }
