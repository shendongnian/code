    <Window x:Class="BindingTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:bindingTest="clr-namespace:BindingTest"
            Title="MainWindow" Height="350" Width="525">
        <Window.DataContext>
            <bindingTest:ViewModel/>
        </Window.DataContext>
        <Grid>
            <StackPanel>
                <ItemsControl ItemsSource="{Binding FailedTests}"/>
                <ProgressBar Value="{Binding TimePassed,Mode=OneWay}"/>
            </StackPanel>
        </Grid>
    </Window>
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    
    namespace BindingTest
    {
        public class TestSummary
        {
            [Description("Test1")]
            public TestResult Test1 { get; set; }
    
            [Description("Test2")]
            public TestResult Test2 { get; set; }
    
            [Description("Test3")]
            public TestResult Test3 { get; set; }
        }
        public enum TestResult
        {
            Failed,
            Passed
        }
    
        public class ViewModel
        {
            private TestSummary TestResults
            {
                get { return new TestSummary()
                {
                    Test1 = TestResult.Failed, 
                    Test2 = TestResult.Passed,
    				Test3 = TestResult.Failed
                }; }
            }
    
            public int TimePassed
            {
                get
                {
                    return 2;
                }
            }
    
            public IEnumerable<String> FailedTests
            {
                get
                {
                    PropertyDescriptorCollection attributes = TypeDescriptor.GetProperties(TestResults);
                    foreach (PropertyInfo failedResult in typeof(TestSummary).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                             .Where(p => p.PropertyType == typeof(TestResult))
                                                             .Where(t => (TestResult)t.GetValue(TestResults,null) == TestResult.Failed))
                    {
                        yield return ((DescriptionAttribute)attributes[failedResult.Name].Attributes[typeof(DescriptionAttribute)]).Description;
                    }
                }
            }
        }
    }
