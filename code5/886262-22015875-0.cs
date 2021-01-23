    private void RepeatingTaskProcessor() {
        // Keep looping until the program is going down.
        while (!IsStopping) {
            // Wait to receive notification that there's something to process.
            StartTask.WaitOne();
            // Exit if the program is stopping now.
            if (IsStopping) return;
            // Execute your task
            PerformTask();
        }
    }
