    namespace AutoLotDAL.EF
    {
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        using System.Data.Entity.Infrastructure.Interception;
        using AutoLotDAL.Interception;
        using AutoLotDAL.Models;
        using System;
        using System.Data.Entity.Core.Objects;
        using System.Web;
        public class AutoLotEntities : DbContext
        {
            //static readonly DatabaseLogger databaseLogger =
            //    new DatabaseLogger($"{HttpRuntime.AppDomainAppPath}/sqllog.txt", true);
            public AutoLotEntities()
                : base("name=AutoLotConnection")
            {
                ////DbInterception.Add(new ConsoleWriterInterceptor());
                //databaseLogger.StartLogging();
                //DbInterception.Add(databaseLogger);
                //// Interceptor code
                //var context = (this as IObjectContextAdapter).ObjectContext;
                //context.ObjectMaterialized += OnObjectMaterialized;
                //context.SavingChanges += OnSavingChanges;
            }
            //void OnObjectMaterialized(object sender,
            //    System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
            //{
            //}
            //void OnSavingChanges(object sender, EventArgs eventArgs)
            //{
            //    // Sender is of type ObjectContext.  Can get current and original values,
            //    // and cancel/modify the save operation as desired.
            //    var context = sender as ObjectContext;
            //    if (context == null)
            //        return;
            //    foreach (ObjectStateEntry item in
            //        context.ObjectStateManager.GetObjectStateEntries(
            //            EntityState.Modified | EntityState.Added))
            //    {
            //        // Do something important here
            //        if ((item.Entity as Inventory) != null)
            //        {
            //            var entity = (Inventory)item.Entity;
            //            if (entity.Color == "Red")
            //            {
            //                item.RejectPropertyChanges(nameof(entity.Color));
            //            }
            //        }
            //    }
            //}
            //protected override void Dispose(bool disposing)
            //{
            //    DbInterception.Remove(databaseLogger);
            //    databaseLogger.StopLogging();
            //    base.Dispose(disposing);
            //}
            public virtual DbSet<CreditRisk> CreditRisks { get; set; }
            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<Inventory> Inventory { get; set; }
            public virtual DbSet<Order> Orders { get; set; }
        }
    }
