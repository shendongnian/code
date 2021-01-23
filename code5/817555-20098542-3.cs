    public class FileUpdateControllerTests
    {
        [Test]
        public void SingleUpdate()
        {
            var scheduler = new TestScheduler();
            var sut = new FileUpdateController<string>(scheduler);
            var task = sut.QueueFileUpdate("test", "1");
            Assert.AreNotEqual(TaskStatus.RanToCompletion, task.Status);
            scheduler.Start();
            Assert.AreEqual(TaskStatus.RanToCompletion, task.Status);
            Assert.AreEqual("test", task.Result);
        }
        [Test]
        public void TwoUpdatesToSameFile()
        {
            var scheduler = new TestScheduler();
            var sut = new FileUpdateController<string>(scheduler);
            var task1 = sut.QueueFileUpdate("test", "1");
            var task2 = sut.QueueFileUpdate("test", "2");
            Assert.AreNotEqual(TaskStatus.RanToCompletion, task1.Status);
            scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks + 1);
            Assert.AreNotEqual(TaskStatus.RanToCompletion, task2.Status);
            Assert.AreEqual(TaskStatus.RanToCompletion, task1.Status);
            scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks + 2);
            Assert.AreEqual(TaskStatus.RanToCompletion, task2.Status);
            Assert.AreEqual("test", task1.Result);
            Assert.AreEqual("test", task2.Result);
        }
        [Test]
        public void TwoUpdatesToDifferentFiles()
        {
            var scheduler = new TestScheduler();
            var sut = new FileUpdateController<string>(scheduler);
            var task1 = sut.QueueFileUpdate("test1", "1");
            var task2 = sut.QueueFileUpdate("test2", "2");
            Assert.AreNotEqual(TaskStatus.RanToCompletion, task1.Status);
            scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks + 1);
            Assert.AreEqual(TaskStatus.RanToCompletion, task1.Status);
            Assert.AreEqual(TaskStatus.RanToCompletion, task2.Status);
            Assert.AreEqual("test1", task1.Result);
            Assert.AreEqual("test2", task2.Result);
        }
        [Test]
        public void UpdatingDataOnPendingFileWorks()
        {
            var scheduler = new TestScheduler();
            var sut = new FileUpdateController<string>(scheduler);
            var task1 = sut.QueueFileUpdate("test", "1");
            var task2 = sut.QueueFileUpdate("test", "2");
            var task3 = sut.QueueFileUpdate("test", "3");
            Assert.AreSame(task2, task3);
            scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks + 1);
            Assert.AreEqual(TaskStatus.RanToCompletion, task1.Status);
            Assert.AreNotEqual(TaskStatus.RanToCompletion, task2.Status);
            scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks + 1);
            Assert.AreEqual(TaskStatus.RanToCompletion, task2.Status);
        }
    }
