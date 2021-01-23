            var subscriptionService = new StripeSubscriptionService();
            var subscriptions = subscriptionService.List(account.StripeCustomerId);
            foreach (var subscription in subscriptions)
            {
                if (subscription.CanceledAt == null)
                    subscriptionService.Cancel(account.StripeCustomerId, subscription.Id);
            }
