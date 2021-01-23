    public class CustomPaymentType
    {
    public string paymentTypeName{get;private set;}
    public int Id{get;private set;}
    
    // if you need "Constant payment types usable in code, just add something like:
    
    
    public static CustomPaymentType CashPayment{
    get{
    return new CustomPaymentType(){Ud = 7,paymentTypeName= "CashPayment"}}}
    
    public static CustomPaymentType CreditPayment{
    get{
    return new CustomPaymentType(){Ud = 7,paymentTypeName= "CreditPayment"}}}
