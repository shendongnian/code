            List<Period> selectedPeriods = e.Argument as List<Period>;
            foreach (Period period in selectedPeriods)
            {
                while (period.Transactions.Count > 0)
                {
                    //operation
                }
                //ui updating
                this.Dispatcher.Invoke(new Action(() => LstTest.Remove(period)), 
                    System.Windows.Threading.DispatcherPriority.Normal);
                //EF updating
                context.Periods.Remove(period);
                
            }
            //context savechanges
}
