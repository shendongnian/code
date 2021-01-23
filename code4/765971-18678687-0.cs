    using System;
    using System.Linq;
    using FluentValidation;
    using FluentValidation.Results;
    
    namespace so.FluentValidationComplexProperties
    {
        internal class Program
        {
            private static void Main( string[] args )
            {
                var oExpense = new Expense();
                oExpense.Transaction = new Transaction();
                oExpense.Transaction.Amount = oExpense.Amount;
                oExpense.Transaction.BankAccountID = 10;
                oExpense.Transaction.TransactionDate = DateTime.Today;
                oExpense.Transaction.IsWithdrawal = true;
                oExpense.Transaction.Description = oExpense.Description;
                oExpense.Transaction.IsDeleted = false;
                // I dont set the below and it should give me validation error:
                // oExpense.Transaction.EmployeeID = 10;
    
    
                var validator = new ExpenseValidator();
                ValidationResult results = validator.Validate( oExpense );
    
                results.Errors.ToList().ForEach( Console.WriteLine );
    
                Console.WriteLine();
                Console.Write( "--done--" );
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    
    
        public class ExpenseBaseValidator : AbstractValidator<Expense>
        {
            public ExpenseBaseValidator()
            {
                RuleFor( x => x.Description ).NotEmpty();
                RuleFor( x => x.Amount ).NotNull();
                RuleFor( x => x.BusinessID ).NotEqual( 0 ).WithMessage( "BusinessID is required." );
                RuleFor( x => x.ExpenseTypeID ).NotEqual( 0 ).WithMessage( "ExpenseTypeID is required." );
                RuleFor( x => x.CreatedDate ).NotNull();
                RuleFor( x => x.Transaction ).SetValidator( new TransactionValidator() );
            }
        }
    
        public class TransactionBaseValidator : AbstractValidator<Transaction>
        {
            public TransactionBaseValidator()
            {
                RuleFor( x => x.BankAccountID ).NotEqual( 0 ).WithMessage( "BankAccountID is required." );
                RuleFor( x => x.EmployeeID ).NotEqual( 0 ).WithMessage( "EmployeeID is required." );
                RuleFor( x => x.TransactionDate ).NotNull();
                RuleFor( x => x.IsWithdrawal ).NotNull();
                RuleFor( x => x.Amount ).NotNull();
                RuleFor( x => x.Description ).NotEmpty();
                RuleFor( x => x.PaymentMethod ).NotEmpty();
                RuleFor( x => x.PaymentMethod ).Length( 0, 50 ).WithMessage( "PaymentMethod can not exceed 50 characters" );
            }
        }
    
        public class ExpenseValidator : ExpenseBaseValidator
        {
            public ExpenseValidator()
                    : base()
            {
                RuleFor( x => x.Transaction )
                        .NotNull()
                        .When( x => x.IsPaid )
                        .WithMessage( "An account transaction is required when the amount is paid." );
    
                RuleFor( x => x.DatePaid )
                        .NotNull()
                        .When( x => x.IsPaid )
                        .WithMessage( "Please enter the date when the expense was paid." );
            }
        }
    
        public class TransactionValidator : TransactionBaseValidator
        {
            public TransactionValidator()
                    : base() {}
        }
    
    
        public class Expense
        {
            public string Description { get; set; }
            public decimal? Amount { get; set; }
            public int BusinessID { get; set; }
            public int ExpenseTypeID { get; set; }
            public DateTime CreatedDate { get; set; }
            public Transaction Transaction { get; set; }
            public bool IsPaid { get; set; }
            public DateTime DatePaid { get; set; }
        }
    
        public class Transaction
        {
            public int BankAccountID { get; set; }
            public int EmployeeID { get; set; }
            public DateTime TransactionDate { get; set; }
            public bool? IsWithdrawal { get; set; }
            public decimal? Amount { get; set; }
            public string Description { get; set; }
            public string PaymentMethod { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
